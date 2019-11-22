@ModelType DemandeViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.LesPiecesDemande
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.LesPiecesDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Demandes")>@Resource.ManageDemande</a></li>
        <li class="breadcrumb-item active">@Resource.LesPiecesDemande</li>
    </ol>
</div>

<div class="container-fluid">

    <h6 class="text-uppercase">@Resource.LesPiecesDemande</h6>
    <hr>
    @Using Html.BeginForm("EditPieces", "Demandes", FormMethod.Post, New With {.enctype = "multipart/form-data"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @Html.HiddenFor(Function(m) m.AnneeBudgetaireId)
        @Html.HiddenFor(Function(m) m.Reference)
        @Html.HiddenFor(Function(m) m.DateDeclaration)
        @Html.HiddenFor(Function(m) m.CollectiviteSinistreeId)
        @Html.HiddenFor(Function(m) m.SinistrerId)
        @Html.HiddenFor(Function(m) m.Observation)

        @<div class="row">
            <div class="col-lg-12">
                <div class="card">
                    <div class="card-body">

                        <div Class="form-group row">
                            @Html.LabelFor(Function(m) m.Sinistrer.Nom, New With {.class = "col-sm-2 col-form-label "})
                            <div class="col-sm-4">
                                @Html.TextBoxFor(Function(m) m.Sinistrer.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder, .Disabled = "DiSabled"})
                                @Html.ValidationMessageFor(Function(m) m.Sinistrer.Nom, "", New With {.style = "color: #da0b0b"})
                            </div>

                            @Html.LabelFor(Function(m) m.Sinistrer.Prenom, New With {.class = "col-sm-2 col-form-label "})
                            <div class="col-sm-4">
                                @Html.TextBoxFor(Function(m) m.Sinistrer.Prenom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder, .Disabled = "DiSabled"})
                                @Html.ValidationMessageFor(Function(m) m.Sinistrer.Prenom, "", New With {.style = "color: #da0b0b"})
                            </div>

                        </div>
                        <div Class="form-group row">
                            @Html.LabelFor(Function(m) m.CollectiviteSinistreeId, New With {.class = "col-sm-2 col-form-label "})
                            <div class="col-sm-4">
                                @Html.TextBoxFor(Function(m) m.CollectiviteSinistree.Libelle, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder, .Disabled = "DiSabled"})
                                @Html.ValidationMessageFor(Function(m) m.CollectiviteSinistree.Libelle, "", New With {.style = "color: #da0b0b"})
                            </div>

                            @Html.LabelFor(Function(m) m.DateDeclaration, New With {.class = "col-sm-2 col-form-label "})
                            <div class="col-sm-4">
                                @Html.TextBoxFor(Function(m) m.DateDeclaration, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.Telephone1Placeholder, .Disabled = "DiSabled"})
                                @Html.ValidationMessageFor(Function(m) m.DateDeclaration, "", New With {.style = "color: #da0b0b"})
                            </div>
                        </div>
                        <br />
                        <br />
                        <br />
                        <div Class="form-group row">
                            <div class="col-sm-4 form-group">

                            </div>
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
                        <br/>
                        <br/>
                        <div>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-primary text-dark shadow px-5"})
                        </div>
                    </div>
                    
                </div>
                    </div>
                </div>

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
