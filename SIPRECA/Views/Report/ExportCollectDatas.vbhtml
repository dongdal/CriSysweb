@ModelType ExportCollectDatasViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.ExportCollectDatas
    Layout = "~/Views/Shared/_LayoutCollecte.vbhtml"
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageReport</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Report")>@Resource.ManageReport</a></li>
        <li class="breadcrumb-item active">@Resource.ExportCollectDatas</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">

            <div id="wizard-vertical">
                <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.ExportCollectDatas</div>
                <hr>
                @Using Html.BeginForm("ExportCollectDatas", "Report", FormMethod.Post, New With {.autocomplete = "off"})
                    @Html.AntiForgeryToken()
                    @Html.HiddenFor(Function(m) m.FormulaireId)
                    @Html.HiddenFor(Function(m) m.EnqueteId)

                    @<div Class="form-group row">
                        @Html.LabelFor(Function(m) m.DateDebut, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.DateDebut, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "1", .Placeholder = Resource.DateDebut})
                            @Html.ValidationMessageFor(Function(m) m.DateDebut, "", New With {.style = "color: #da0b0b"})
                        </div>

                        @Html.LabelFor(Function(m) m.DateFin, New With {.class = "col-sm-2 col-form-label required_field"})
                        <div class="col-sm-4">
                            @Html.TextBoxFor(Function(m) m.DateFin, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "2", .Placeholder = Resource.DateFin})
                            @Html.ValidationMessageFor(Function(m) m.DateFin, "", New With {.style = "color: #da0b0b"})
                        </div>
                    </div>

                    @*@<div id="dateragne-picker">
                        <div class="input-daterange input-group">
                            <input type="text" class="form-control" name="start">
                            <div class="input-group-prepend">
                                <span class="input-group-text">to</span>
                            </div>
                            <input type="text" class="form-control" name="end">
                        </div>
                    </div>*@



                    @<div Class="form-group row">
                        <Label Class="col-sm-4 col-form-label"></Label>
                        <div Class="col-sm-5">
                            @Html.ActionLink(Resource.btn_Previous, "CreateFromulaire", "Enquetes", New With {.EnqueteId = Model.EnqueteId}, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                            &nbsp;&nbsp;&nbsp;
                            <Button type="button" id="lnkReport" Class="btn btn-link btn-square bg-primary text-dark shadow px-5">
                                @Resource.BtnPrint
                                <i Class="icon-printer"></i>
                            </Button>

                        </div>
                    </div>

                End Using

                <div class="row">
                    <div class="col-md-9">
                        <div class="embed-responsive embed-responsive-16by9">
                            <iframe id="ifrReport" class="embed-responsive-item"></iframe>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</div>


@Section Scripts
    <script>
    $('#lnkReport').on('click', function () {
            var DateDebut = $('#DateDebut').val();
        var DateFin = $('#DateFin').val();
        var FormulaireId = $('#FormulaireId').val();
        if (!FormulaireId)
        {
            $.alert("Aucun formulaire n'a été sélectionné. Impossible d'imprimer le rapport");
        }
        $('#ifrReport').attr('src', '@Url.Content("~/Report/Report.aspx")?DateDebut=' + DateDebut + '&DateFin=' + DateFin + '&FormulaireId=' + FormulaireId +'&type=ExportCollectDatas')

    });

    </script>

End Section