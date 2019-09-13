@ModelType ElementViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.CreateElement
End Code



<div class="page-header">
    <h1 class="page-title">@Resource.ManageElement</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Elements")>@Resource.ManageElement</a></li>
        <li class="breadcrumb-item active">@Resource.CreateElement</li>
    </ol>
</div>

<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.CreateElement</div>
            <hr>
            @Using Html.BeginForm("Create", "Elements", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Nom, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Nom, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.NomPaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Nom, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.Code, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Code, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.CODEPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Code, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.CategorieElementId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.CategorieElementId, New SelectList(Model.LesCategorieElements, "Value", "Text"), Resource.ComboCategorieElement,
                New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboCategorieElement})
                        @Html.ValidationMessageFor(Function(m) m.CategorieElementId, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.MarqueElementId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.MarqueElementId, New SelectList(Model.LesMarqueElements, "Value", "Text"), Resource.ComboMarqueElement,
                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboMarqueElement})
                        @Html.ValidationMessageFor(Function(m) m.MarqueElementId, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.UniteMesure, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.UniteMesure, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.UniteMesurePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.UniteMesure, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.LabelFor(Function(m) m.ValeurParUnité, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.ValeurParUnité, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.ValeurParUnitePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.ValeurParUnité, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Modele, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Modele, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.ModelePlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Modele, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.LabelFor(Function(m) m.AnneeFabrication, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.AnneeFabrication, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.AnneeFabricationPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.AnneeFabrication, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Longueur, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Longueur, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.LongueurPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Longueur, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.LabelFor(Function(m) m.Largeur, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Largeur, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.LargeurPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Largeur, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.Hauteur, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Hauteur, New With {.class = "form-control form-control-square default-datepicker", .tabindex = "4", .Placeholder = Resource.HauteurPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Hauteur, "", New With {.style = "color: #da0b0b"})
                    </div>


                    @Html.LabelFor(Function(m) m.Poids, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.Poids, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.PoidsPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.Poids, "", New With {.style = "color: #da0b0b"})
                    </div>
                </div>

                @<div Class="form-group row">

                    @Html.LabelFor(Function(m) m.PrixAchat, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4">
                        @Html.TextBoxFor(Function(m) m.PrixAchat, New With {.class = "form-control form-control-square", .tabindex = "1", .Placeholder = Resource.PrixAchatPlaceholder})
                        @Html.ValidationMessageFor(Function(m) m.PrixAchat, "", New With {.style = "color: #da0b0b"})
                    </div>

                    @Html.LabelFor(Function(m) m.DeviseId, New With {.class = "col-sm-2 col-form-label"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.DeviseId, New SelectList(Model.LesDevises, "Value", "Text"), Resource.ComboDevise,
                         New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboDevise})
                        @Html.ValidationMessageFor(Function(m) m.DeviseId, "", New With {.style = "color: #da0b0b"})
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
