@ModelType DemandeViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditDemande
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.EditDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Demandes")>@Resource.ManageDemande</a></li>
        <li class="breadcrumb-item active">@Resource.EditDemande</li>
    </ol>
</div>

<div class="container-fluid">

    <h6 class="text-uppercase">@Resource.EditDemande</h6>
    <hr>
    @Using Html.BeginForm("Edit", "Demandes", FormMethod.Post, New With {.enctype = "multipart/form-data"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @<div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">
                        <ul class="nav nav-tabs nav-tabs-primary">
                            <li class="nav-item">
                                <a class="nav-link active" data-toggle="tab" href="#tabe-1"><i class="icon-home"></i> <span class="hidden-xs">Demande</span></a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" data-toggle="tab" href="#tabe-2"><i class="icon-user"></i> <span class="hidden-xs">Pièces jointes</span></a>
                            </li>
                        </ul>

                        <!-- Tab panes -->
                        <div class="tab-content">
                            <div id="tabe-1" class="container tab-pane active">

                                <div Class="form-group row">
                                    @Html.LabelFor(Function(m) m.Reference, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4">
                                        @Html.TextBoxFor(Function(m) m.Reference, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.ReferencePlaceholder})
                                        @Html.ValidationMessageFor(Function(m) m.Reference, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                    @Html.LabelFor(Function(m) m.CollectiviteSinistreeId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.CollectiviteSinistreeId, New SelectList(Model.LesCollectiviteSinistrees, "Value", "Text"), Resource.ComboCollectiviteSinistree,
       New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistre})
                                        @Html.ValidationMessageFor(Function(m) m.CollectiviteSinistreeId, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                </div>

                                <div Class="form-group row">

                                    @Html.LabelFor(Function(m) m.SinistrerId, New With {.class = "col-sm-2 col-form-label required_field"})
                                    <div class="col-sm-4 form-group">
                                        @Html.DropDownListFor(Function(m) m.SinistrerId, New SelectList(Model.LesSinistrers, "Value", "Text"), Resource.ComboSinistrer,
       New With {.class = "form-control single-select", .tabindex = "3", .Placeholder = Resource.ComboSinistrer})
                                        @Html.ValidationMessageFor(Function(m) m.SinistrerId, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                </div>

                                <div Class="form-group row">
                                    <Label Class="col-sm-2 col-form-label"></Label>
                                    <div Class="col-sm-10">
                                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                                        &nbsp;&nbsp;&nbsp;
                                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                                    </div>
                                </div>

                            </div>
                            <div id="tabe-2" class="container tab-pane fade">

                                <div Class="form-group row">

                                    <div class="col-sm-4 form-group">
                                        <input type="file" class="custom-file-input" multiple="multiple" id="Fichiers" name="Fichiers">
                                        <label class="custom-file-label" for="Fichiers">@Resource.PieceJointe</label>
                                    </div>

                                    <div class="col-sm-4 form-group">
                                        <input type="submit" value="@Resource.Uploader" name="AddAttachement" class="btn btn-primary btn-sm" />
                                    </div>
                                </div>

                                <br />

                                <table id="zero_config" class="table table-striped table-bordered">
                                    <thead>
                                        <tr>

                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.DateCreation
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.BtnDownload
                                            </th>
                                            <th class="sorting_asc text-center" tabindex="0" aria-controls="datatable-responsive">
                                                @Resource.ActionList
                                            </th>
                                        </tr>
                                    </thead>

                                    <tbody>
                                        @For Each item In Model.PiecesJointes
                                            @<tr>

                                                <td>
                                                    @item.DateCreation
                                                </td>

                                                <td class="text-center">

                                                    <a class="title" title="@Resource.DownloadFile" download="@item.Libelle" href="@item.Lien" style="cursor: pointer;">
                                                        @item.Libelle
                                                    </a>

                                                </td>

                                                <td>
                                                    <a class="btn btn-round btn-danger waves-effect waves-light m-1 deleteItem" title="@Resource.Btn_Delete" href="javascript:void(0);" data-id="@item.Id">
                                                        <i class="fa fa-trash" aria-hidden="true"></i>
                                                    </a>
                                                </td>
                                            </tr>
                                        Next
                                    </tbody>

                                </table>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
        '<!--End Row-->
    End Using

</div>


@Section Scripts

    <script>

        $('.deleteItem').click(function (e) {
            e.preventDefault();
            var $ctrl = $(this);
            var Id = $(this).data("id");
            //$.alert("Identifiant= " + Id);
            $.confirm({
                title: '@Resource.Btn_Delete',
                content: '@Resource.ConfirmDelete',
                animationSpeed: 1000,
                animationBounce: 3,
                animation: 'rotatey',
                closeAnimation: 'scaley',
                theme: 'supervan',
                buttons: {
                    Confirmer: function () {
                        $.ajax({
                            url: '@Url.Action("DeleteFile")',
                            type: 'POST',
                            data: { id: Id }
                        }).done(function (data) {
                            if (data.Result == "OK") {
                                //$ctrl.closest('li').remove();
                                $.confirm({
                                    title: '@Resource.SuccessTitle',
                                    content: '@Resource.SuccessProcess',
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
                            content: '@Resource.CancelingConfirmed',
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
        });

    </script>

End Section
