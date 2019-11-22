@ModelType PagedList.IPagedList(Of Demande)
@Imports PagedList.Mvc
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ListDemande
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Demandes")>@Resource.ManageDemande</a></li>
        <li class="breadcrumb-item active">@Resource.ListDemande</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ListDemande</div>
            <hr>
            @Using Html.BeginForm("Index", "Demandes", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="col-sm-12">

                    <div Class="row col-sm-12">
                        @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional)) Then
                            @<div Class="col-md-4">
                                @Html.DropDownList("RegionId", DirectCast(ViewBag.RegionIds, IEnumerable(Of SelectListItem)), Resource.ComboRegion, New With {.class = "form-control single-select", .onchange = "LoadDepartement()"})
                            </div>
                        End If

                        @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional) Or AppSession.Niveau.Equals(Util.UserLevel.Departemental)) Then
                            @<div Class="col-md-4">
                                @Html.DropDownList("DepartementId", DirectCast(ViewBag.DepartementIds, IEnumerable(Of SelectListItem)), Resource.ComboDepartement, New With {.class = "form-control single-select", .onchange = "LoadCommune()"})
                            </div>
                        End If

                        @If (AppSession.Niveau.Equals(Util.UserLevel.National) Or AppSession.Niveau.Equals(Util.UserLevel.Regional) Or AppSession.Niveau.Equals(Util.UserLevel.Departemental) Or AppSession.Niveau.Equals(Util.UserLevel.Communal)) Then
                            @<div Class="col-md-4">
                                @Html.DropDownList("CommuneId", DirectCast(ViewBag.CommuneIds, IEnumerable(Of SelectListItem)), Resource.CommuneCombo, New With {.class = "form-control single-select"})
                            </div>
                        End If
                    </div>

                </div>

                @<br />

                @<div Class="form-inline padding-bottom-1">
                    <div Class="row col-sm-12">
                        <div Class="col-sm-2">
                            <div Class="form-group">
                                @*<a class="btn btn-round btn-primary waves-effect waves-light m-1" title="@Resource.Btn_nouveau" href="@Url.Action("Create")">
                                    <i Class="fa fa-plus" aria-hidden="true"></i>
                                    @Resource.Btn_nouveau
                                </a>*@
                            </div>
                        </div>

                        <div Class="col-sm-4">
                            <div Class="col-md-12">
                                @Html.DropDownList("EtatAvancement", DirectCast(ViewBag.StatutDemande, IEnumerable(Of SelectListItem)), Resource.StatutDemandeCombo, New With {.class = "form-control single-select"})
                            </div>
                        </div>

                        <div class="col-sm-4 text-right">
                            <div class="input-group mb-4">
                                @Html.TextBox("SearchString", CStr(ViewBag.CurrentFilter), New With {.class = "form-control round", .placeholder = Resource.Find})
                                <div class="input-group-append">
                                    @*<button class="btn btn-primary" type="submit"><i class="fa fa-search"></i></button>*@
                                </div>
                            </div>
                        </div>

                        <div Class="col-sm-2">
                            <div Class="form-group">
                                <button class="btn btn-round  btn btn-dark" type="submit" value="@Resource.BtnFiltrer"> <i class="fa fa-search"></i> @Resource.BtnFiltrer</button>
                            </div>
                        </div>

                    </div>
                </div>

            End Using

            <br />
            <table id="default-datatable" class="table table-bordered dataTable" role="grid" aria-describedby="default-datatable_info">
                <thead>
                    <tr>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Ordre, "Index", New With {.sortOrder = ViewBag.IDSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Sinistre, "Index", New With {.sortOrder = ViewBag.CollectiviteSinistreeSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.LeSinistrer, "Index", New With {.sortOrder = ViewBag.SinistrerSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
                        </th>
                        @*<th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
            @Html.ActionLink(Resource.Statut, "Index", New With {.sortOrder = ViewBag.StatutExistantSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
        </th>*@
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.DateDeclaration, "Index", New With {.sortOrder = ViewBag.DateDeclarationSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Html.ActionLink(Resource.Statut, "Index", New With {.sortOrder = ViewBag.StatutSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement})
                        </th>
                        <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                            @Resource.ActionList
                        </th>
                    </tr>
                </thead>

                <tbody>
                    @For Each item In Model
                        @<tr>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.Id)
                            </td>
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.CollectiviteSinistree.Libelle)
                            </td>
                            <td class="sorting_asc text-center">
                                @item.Sinistrer.Nom @item.Sinistrer.Prenom <br /> @Resource.CNI:  @item.Sinistrer.Cni
                            </td>
                            @*<td class="sorting_asc text-center">
                                    @Html.DisplayFor(Function(modelItem) item.StatutExistant)
                                </td>*@
                            <td class="sorting_asc text-center">
                                @Html.DisplayFor(Function(modelItem) item.DateDeclaration)
                            </td>
                            <td class="sorting_asc text-center">
                                @if item.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal Or
item.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental Or
item.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional Or
item.StatutExistant = Util.ElementsSuiviDemandes.CreationNational Then

                            @Resource.StatutEnCour

                                ElseIf item.StatutExistant = Util.ElementsSuiviDemandes.ValidationCommunal Or
                                                        item.StatutExistant = Util.ElementsSuiviDemandes.ValidationDepartemental Or
                                                        item.StatutExistant = Util.ElementsSuiviDemandes.ValidationRegional Or
                                                        item.StatutExistant = Util.ElementsSuiviDemandes.ValidationNational Then

                            @Resource.StatutEnCour

                                ElseIf item.StatutExistant = Util.ElementsSuiviDemandes.RejetCommunal Or
                                                                                    item.StatutExistant = Util.ElementsSuiviDemandes.RejetDepartemental Or
                                                                                    item.StatutExistant = Util.ElementsSuiviDemandes.RejetRegional Or
                                                                                    item.StatutExistant = Util.ElementsSuiviDemandes.RejetNational Then

                            @Resource.StatutRejeter

                                ElseIf item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionDepartemental Or
                                                                                item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionRegionale Or
                                                                                item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionNational Then

                            @Resource.StatutEnCour

                                ElseIf item.StatutExistant = Util.ElementsSuiviDemandes.TransfertCommunal Or
                                                    item.StatutExistant = Util.ElementsSuiviDemandes.TransfertDepartemental Or
                                                    item.StatutExistant = Util.ElementsSuiviDemandes.TransfertRegional Then

                            @Resource.StatutEnCour

                                ElseIf item.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation Then

                            @Resource.StatutIndemniser

                                End If
                            </td>
                            <td class="text-center">

                                @If item.Indemnisation.Select(Of Demande)(Function(e) e.Demande).Count >= 1 Then
                                    Dim indem = item.Indemnisation.Select(Of Long)(Function(e) e.Id).FirstOrDefault
                                    @<a Class="btn btn-round btn-info waves-effect waves-light m-1" title="@Resource.BtnInfoIndemnisation" href="@Url.Action("Details", "Indemnisations", New With {.id = indem})">
                                        <i Class="fa fa-list" aria-hidden="true"></i>
                                    </a>
                                ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal Or item.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental Or
                                    item.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional Or item.StatutExistant = Util.ElementsSuiviDemandes.CreationNational) Then
                                    @<a Class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                        <i Class="fa fa-edit" aria-hidden="true"></i>
                                    </a>
                                    @<a class="btn btn-round btn-danger waves-effect waves-light m-1" title="@Resource.Btn_Delete" href="@Url.Action("Delete", New With {.id = item.Id})">
                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                    </a>
                                End If


                                @If (AppSession.Niveau.Equals(Util.UserLevel.Communal)) Then

                                    If (item.StatutExistant = Util.ElementsSuiviDemandes.CreationCommunal) Then

                                        @<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.CreationCommunal)' ,'@item.Id')" data-id="@item.Id">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ValidationCommunal) Then

                                        @<a class="btn btn-round btn-gradient-ibiza waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetCommunal)' ,'@item.Id')">
                                            <i class="fa fa-times" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-bloody waves-effect waves-light m-1 " title="@Resource.TransfertDemande" onclick="Transfert('@CInt(Util.ElementsSuiviDemandes.TransfertCommunal)' ,'@item.Id')">
                                            <i class="fa fa-exchange" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-success waves-effect waves-light m-1 " title="@Resource.IndemniserSinistre" href="@Url.Action("Create", "Indemnisations", New With {.DemandeId = item.Id})">
                                            <i class="fa fa-money" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.RejetCommunal) Then

                                        @*@<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.RejetCommunal)' ,'@item.Id')">
                    <i class="fa fa-check" aria-hidden="true"></i>
                </a>*@

                                        @*@<a class="btn btn-round btn-gradient-ibiza waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetCommunal)' ,'@item.Id')">
                    <i class="fa fa-times" aria-hidden="true"></i>
                </a>*@
                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertCommunal Or item.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation) Then

                                        @*@<a class="btn btn-round btn-inverse-primary waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetCommunal)' ,'@item.Id')">
                    <i class="fa fa-trash" aria-hidden="true"></i>
                </a>*@

                                    End If

                                ElseIf (AppSession.Niveau.Equals(Util.UserLevel.Departemental)) Then

                                    If (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertCommunal) Then

                                        @<a class="btn btn-round btn-danger waves-effect waves-light m-1 " title="@Resource.ReceptionDemande" onclick="Reception('@CInt(Util.ElementsSuiviDemandes.ReceptionDepartemental)' ,'@item.Id')">
                                            <i class="fa fa-download" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionDepartemental Or item.StatutExistant = Util.ElementsSuiviDemandes.CreationDepartemental) Then
                                        @<a Class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                            <i Class="fa fa-edit" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.CreationDepartemental)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ValidationDepartemental) Then

                                        @<a class="btn btn-round btn-gradient-ibiza waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetDepartemental)' ,'@item.Id')">
                                            <i class="fa fa-times" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-bloody waves-effect waves-light m-1 " title="@Resource.TransfertDemande" onclick="Transfert('@CInt(Util.ElementsSuiviDemandes.TransfertDepartemental)' ,'@item.Id')">
                                            <i class="fa fa-exchange" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-success waves-effect waves-light m-1 " title="@Resource.IndemniserSinistre" href="@Url.Action("Create", "Indemnisations", New With {.DemandeId = item.Id})">
                                            <i class="fa fa-money" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.RejetDepartemental) Then

                                        @*@<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.RejetDepartemental)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>*@

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertDepartemental Or item.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation) Then


                                    End If

                                ElseIf (AppSession.Niveau.Equals(Util.UserLevel.Regional)) Then

                                    If (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertDepartemental) Then

                                        @<a class="btn btn-round btn-danger waves-effect waves-light m-1 " title="@Resource.ReceptionDemande" onclick="Reception('@CInt(Util.ElementsSuiviDemandes.ReceptionRegionale)' ,'@item.Id')">
                                            <i class="fa fa-download" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionRegionale Or item.StatutExistant = Util.ElementsSuiviDemandes.CreationRegional) Then
                                        @<a Class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                            <i Class="fa fa-edit" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.CreationRegional)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ValidationRegional) Then

                                        @<a class="btn btn-round btn-gradient-ibiza waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetRegional)' ,'@item.Id')">
                                            <i class="fa fa-times" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-bloody waves-effect waves-light m-1 " title="@Resource.TransfertDemande" onclick="Transfert('@CInt(Util.ElementsSuiviDemandes.TransfertRegional)' ,'@item.Id')">
                                            <i class="fa fa-exchange" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-success waves-effect waves-light m-1 " title="@Resource.IndemniserSinistre" href="@Url.Action("Create", "Indemnisations", New With {.DemandeId = item.Id})">
                                            <i class="fa fa-money" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.RejetRegional) Then

                                        @*@<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.RejetRegional)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>*@

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertRegional Or item.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation) Then


                                    End If
                                Else

                                    If (item.StatutExistant = Util.ElementsSuiviDemandes.TransfertRegional) Then

                                        @<a class="btn btn-round btn-danger waves-effect waves-light m-1 " title="@Resource.ReceptionDemande" onclick="Reception('@CInt(Util.ElementsSuiviDemandes.ReceptionNational)' ,'@item.Id')">
                                            <i class="fa fa-download" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ReceptionRegionale Or item.StatutExistant = Util.ElementsSuiviDemandes.CreationNational) Then
                                        @<a Class="btn btn-round btn-warning waves-effect waves-light m-1" title="@Resource.Btn_Edit" href="@Url.Action("Edit", New With {.id = item.Id})">
                                            <i Class="fa fa-edit" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.CreationNational)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.ValidationNational) Then

                                        @<a class="btn btn-round btn-gradient-ibiza waves-effect waves-light m-1 " title="@Resource.RejetDemande" onclick="Rejeter('@CInt(Util.ElementsSuiviDemandes.RejetNational)' ,'@item.Id')">
                                            <i class="fa fa-times" aria-hidden="true"></i>
                                        </a>

                                        @<a class="btn btn-round btn-success waves-effect waves-light m-1 " title="@Resource.IndemniserSinistre" href="@Url.Action("Create", "Indemnisations", New With {.DemandeId = item.Id})">
                                            <i class="fa fa-money" aria-hidden="true"></i>
                                        </a>

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.RejetNational) Then

                                        @*@<a class="btn btn-round btn-gradient-quepal waves-effect waves-light m-1 " title="@Resource.ValiderDemande" onclick="validation('@CInt(Util.ElementsSuiviDemandes.RejetNational)' ,'@item.Id')">
                                            <i class="fa fa-check" aria-hidden="true"></i>
                                        </a>*@

                                    ElseIf (item.StatutExistant = Util.ElementsSuiviDemandes.DecisionIndemnisation) Then


                                    End If

                                End If

                            </td>
                        </tr>
                    Next
                </tbody>

            </table>

            @Html.PagedListPager(Model, Function(page) Url.Action("Index",
                                                                                                                   New With {.page = page, .sortOrder = ViewBag.CurrentSort, .currentFilter = ViewBag.CurrentFilter, .tab = ViewBag.activeTab, .RegionId = ViewBag.PageRegionId, .DepartementId = ViewBag.PageDepartementId, .CommuneId = ViewBag.PageCommuneId, .EtatAvancement = ViewBag.EtatAvancement}))
            Page @IIf(Model.PageCount < Model.PageNumber, 0, Model.PageNumber) @Resource.RecordsOn @Model.PageCount (@ViewBag.EnregCount @Resource.Records)

        </div>

    </div>
</div>


@Section Scripts


    <script>

        function LoadCommune() {
            //alert("Le niveau sélectionné = " + $(cboPereId).val());
            var cboPereId = '#DepartementId';
            var cboFilsId = '#CommuneId';
            //Dropdownlist Selectedchange event
            //$.alert("DepartementId = " + $(cboPereId).val());
            var url = '@Url.Action("CommuneParDepartement")';
            var MsgCombo = '@Resource.CommuneCombo';
                if ($(cboPereId).val()) {
                    $(cboFilsId).empty();
                    if ($(cboPereId).val()) {

                        $.ajax({
                            type: 'POST',
                            url: url, // we are calling json method

                            dataType: 'json',

                            data: { id_pere: $(cboPereId).val() },
                            // here we are get value of selected country and passing same value as inputto json method GetStates.

                            success: function (states) {
                                // states contains the JSON formatted list
                                // of states passed from the controller

                                $(cboFilsId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                                $.each(states, function (i, state) {
                                    $(cboFilsId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                    // here we are adding option for States

                                });
                            },
                            error: function (ex) {
                                //alert('Failed to retrieve states.' + ex);
                            }
                        });
                    } else {
                        $(cboFilsId).append('<option value="">' + MsgCombo + '</option>');
                    };
                }
        }

        function LoadDepartement() {
            //alert("Le niveau sélectionné = " + $(cboPereId).val());
            var cboPereId = '#RegionId';
            var cboFilsId = '#DepartementId';
            var cboPetitFilsId = '#CommuneId';
            //Dropdownlist Selectedchange event
            //$.alert("RegionId = " + $(cboPereId).val());
            var url = '@Url.Action("DepartementParRegion")';
            var MsgCombo = '@Resource.ComboDepartement';
            var MsgComboCommune = '@Resource.CommuneCombo';
                if ($(cboPereId).val()) {
                    $(cboFilsId).empty();
                    $(cboPetitFilsId).empty();
                    if ($(cboPereId).val()) {

                        $.ajax({
                            type: 'POST',
                            url: url, // we are calling json method

                            dataType: 'json',

                            data: { id_pere: $(cboPereId).val() },
                            // here we are get value of selected country and passing same value as inputto json method GetStates.

                            success: function (states) {
                                // states contains the JSON formatted list
                                // of states passed from the controller

                                $(cboFilsId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                                $(cboPetitFilsId).append('<option value="">' + MsgComboCommune + '</option>'); // ici on met d'abord unn premier elt vide
                                $.each(states, function (i, state) {
                                    $(cboFilsId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                    // here we are adding option for States

                                });
                            },
                            error: function (ex) {
                                //alert('Failed to retrieve states.' + ex);
                            }
                        });
                    } else {
                        $(cboFilsId).append('<option value="">' + MsgCombo + '</option>');
                        $(cboPetitFilsId).append('<option value="">' + MsgComboCommune + '</option>');
                    };
                }
        }

        function validation(status, id) {

            var type;

            if (status == '@CInt(Util.ElementsSuiviDemandes.CreationCommunal)' @*|| status == '@Util.ElementsSuiviDemandes.RejetCommunal'*@)
            {
                //alert(status);
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationCommunal)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.CreationDepartemental)' @*|| status == '@Util.ElementsSuiviDemandes.RejetDepartemental'*@)
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationDepartemental)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.CreationRegional)' @*|| status == '@Util.ElementsSuiviDemandes.RejetRegional'*@)
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationRegional)';
            } else
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationNational)';
            }


            //$.alert("Identifiant= " + Type);
            $.confirm({
                title: '@Resource.ValiderDemande',
                content: '@Resource.ConfirmValidation',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("ConfirmSuivi")',
                            type: 'POST',
                            data: { id: id, type: type}
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessValidation',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingValidation',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        }


        function Rejeter(status, id)
        {

            var type;

            if (status == '@CInt(Util.ElementsSuiviDemandes.RejetCommunal)')
            {

                type = '@CInt(Util.ElementsSuiviDemandes.RejetCommunal)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.RejetDepartemental)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.RejetDepartemental)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.RejetRegional)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ReceptionRegionale)';
            } else
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.RejetNational)';
            }

            //$.alert("Identifiant= " + Type);
            $.confirm({
                title: '@Resource.RejetDemande',
                content: '@Resource.ConfirmRejet',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("RejetSuivi")',
                            type: 'POST',
                            data: { id: id, type: type}
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessRejet',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingRejet',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        }


        function Transfert(status, id)
        {

            var type;

            if (status == '@CInt(Util.ElementsSuiviDemandes.TransfertCommunal)')
            {

                type = '@CInt(Util.ElementsSuiviDemandes.TransfertCommunal)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.TransfertDepartemental)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.TransfertDepartemental)';

            } else if (status == '@CInt(Util.ElementsSuiviDemandes.TransfertRegional)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.TransfertRegional)';
            }


            //$.alert("Identifiant= " + Type);
            $.confirm({
                title: '@Resource.TransfertDemande',
                content: '@Resource.ConfirmTransfert',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("TransfertSuivi")',
                            type: 'POST',
                            data: { id: id, type: type}
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessTransfert',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingTransfert',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        }

        function Reception(status, id)
        {

            var type;

            if (status == '@CInt(Util.ElementsSuiviDemandes.ReceptionDepartemental)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ReceptionDepartemental)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.ReceptionRegionale)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationCommunal)';
            } else if (status == '@CInt(Util.ElementsSuiviDemandes.ReceptionNational)')
            {
                //alert(status)
                type = '@CInt(Util.ElementsSuiviDemandes.ValidationCommunal)';
            }


            //$.alert("Identifiant= " + Type);
            $.confirm({
                title: '@Resource.ReceptionDemande',
                content: '@Resource.ConfirmReception',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("ReceptionSuivi")',
                            type: 'POST',
                            data: { id: id, type: type}
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessReception',
                                    animationSpeed: 1000,
                                    animationBounce: 3,
                                    animation: 'rotatey',
                                    closeAnimation: 'scaley',
                                    theme: 'supervan',
                                    buttons: {
                                        OK: function () {
                                            window.location.reload();
                                        }
                                    }
                                });
                            }
                            else if (data.Result.Message) {
                                alert(data.Result.Message);
                            }
                        }).fail(function () {
                            @*//$.alert('@Resource.ErrorProcess');*@
                            $.confirm({
                                title: '@Resource.ErreurTitle',
                                content: '@Resource.ErrorProcess',
                                animationSpeed: 1000,
                                animationBounce: 3,
                                animation: 'rotatey',
                                closeAnimation: 'scaley',
                                theme: 'supervan',
                                buttons: {
                                    OK: function () {
                                    }
                                }
                            });
                        })
                    },
                    Annuler: function () {
                        $.confirm({
                            title: '@Resource.CancelingProcess',
                            content: '@Resource.CancelingReception',
                            animationSpeed: 1000,
                            animationBounce: 3,
                            animation: 'rotatey',
                            closeAnimation: 'scaley',
                            theme: 'supervan',
                            buttons: {
                                OK: function () {
                                }
                            }
                        });
                    }
                }
            });
        }


    </script>

    @*<script>

            //alert("Le niveau sélectionné = " + $(cboPereId).val());
            var cboGrdPereId = '#RegionId';
            var cboPereId = '#DepartementId';
            var cboFilsId = '#CommuneId';
            //Dropdownlist Selectedchange event
            $(cboPereId).change(function () {
                //alert("Le niveau sélectionné = " + $(cboPereId).val());
            var url = '@Url.Action("CommuneParDepartement")';
            var MsgCombo = '@Resource.CommuneCombo';

                //document.getElementById(CommuneDiv).style.display = (Niveau == 1) ? '' : 'none';
                if ($(cboPereId).val()) {
                    $(cboFilsId).empty();
                    if ($(cboPereId).val()) {

                        $.ajax({
                            type: 'POST',
                            url: url, // we are calling json method

                            dataType: 'json',

                            data: { id_pere: $(cboPereId).val() },
                            // here we are get value of selected country and passing same value as inputto json method GetStates.

                            success: function (states) {
                                // states contains the JSON formatted list
                                // of states passed from the controller

                                $(cboFilsId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                                $.each(states, function (i, state) {
                                    $(cboFilsId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                    // here we are adding option for States

                                });
                            },
                            error: function (ex) {
                                //alert('Failed to retrieve states.' + ex);
                            }
                        });
                    } else {
                        $(cboFilsId).append('<option value="">' + MsgCombo + '</option>');
                    };
                }

                return false;
            })

        //Dropdownlist Selectedchange event
            $(cboGrdPereId).change(function () {
            var url = '@Url.Action("DepartementParRegion")';
            var MsgCombo = '@Resource.ComboDepartement';

            //document.getElementById(CommuneDiv).style.display = (Niveau == 1) ? '' : 'none';
            if ($(cboGrdPereId).val()) {
                $(cboPereId).empty();
                $(cboFilsId).empty();
                if ($(cboGrdPereId).val()) {

                    $.ajax({
                        type: 'POST',
                        url: url, // we are calling json method

                        dataType: 'json',

                        data: { id_pere: $(cboGrdPereId).val() },
                        // here we are get value of selected country and passing same value as inputto json method GetStates.

                        success: function (states) {
                            // states contains the JSON formatted list
                            // of states passed from the controller

                            $(cboPereId).append('<option value="">' + MsgCombo + '</option>'); // ici on met d'abord unn premier elt vide
                            $.each(states, function (i, state) {
                                $(cboPereId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                // here we are adding option for States

                            });
                        },
                        error: function (ex) {
                            //alert('Failed to retrieve states.' + ex);
                        }
                    });
                } else {
                    $(cboPereId).append('<option value="">' + MsgCombo + '</option>');
                };
            }

            return false;
        })






            $(document).ready(function () {
                var cboPereId = '#RegionId';
                var cboFilsId = '#DepartementId';
                var url = '@Url.Action("DepartementParRegion")';
                //Dropdownlist Selectedchange event
                $(cboPereId).change(function () {
                    $(cboFilsId).empty();
                    if ($(cboPereId).val()) {

                        $.ajax({
                            type: 'POST',
                            url: url, // we are calling json method

                            dataType: 'json',

                            data: { id_pere: $(cboPereId).val() },
                            // here we are get value of selected country and passing same value as inputto json method GetStates.

                            success: function (states) {
                                // states contains the JSON formatted list
                                // of states passed from the controller

                                    $(cboFilsId).append('<option value="">' +  @Resource.ComboDepartement + '</option>'); // ici on met d'abord unn premier elt vide
                                $.each(states, function (i, state) {
                                    $(cboFilsId).append('<option value="' + state.Value + '">' + state.Text + '</option>');
                                    // here we are adding option for States

                                });
                            },
                            error: function (ex) {
                                alert('Failed to retrieve states.' + ex);
                            }
                        });
                    } else {
                        $(cboFilsId).append('<option value="">@Resource.ComboDepartement</option>');
                    };

                    return false;
                })
            });
            </script>*@

End Section