@ModelType DemandeViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateDemande
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageDemande</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Demandes")>@Resource.ManageDemande</a></li>
        <li class="breadcrumb-item active">@Resource.CreateDemande</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateDemande</div>
            <hr>
            @Using Html.BeginForm("Create", "Demandes", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()


                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Reference, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Reference, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.ReferencePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Reference, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.SinistreId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.SinistreId, New SelectList(Model.Sinistres, "Value", "Text"), Resource.ComboSinistre,
      New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistre})
                        @Html.ValidationMessageFor(Function(m) m.SinistreId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.SinistrerId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.SinistrerId, New SelectList(Model.Sinistrer, "Value", "Text"), Resource.ComboSinistrer,
             New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboSinistrer})
                        @Html.ValidationMessageFor(Function(m) m.SinistrerId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>


                @<div Class="form-group row">
                    <Label Class="col-sm-2 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <Button type="submit" Class="btn btn-link btn-square bg-primary text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.BtnSave</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>
