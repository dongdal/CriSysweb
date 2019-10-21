@ModelType SIPRECA.AutreImpactHumainEtEconomiqueViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewData("Title") = Resource.EditIndicateursAutreImpactHumainEtEconomique
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "AutreImpactHumainEtEconomique")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditIndicateursAutreImpactHumainEtEconomique</li>
    </ol>
</div>


<div class="container-fluid">

    <div class="card">
        <div class="card-body">
            <div class="card-title text-uppercase"><i class="fa fa-address-book-o"></i> @Resource.EditIndicateursAutreImpactHumainEtEconomique</div>
            <hr>
            @Using Html.BeginForm("Edit", "AutreImpactHumainEtEconomique", FormMethod.Post, New With {.autocomplete = "off"})
                @Html.AntiForgeryToken()
                @Html.HiddenFor(Function(model) model.Id)
                @Html.HiddenFor(Function(model) model.AspNetUserId)
                @Html.HiddenFor(Function(model) model.StatutExistant)
                @Html.HiddenFor(Function(model) model.DateCreation)

                @<div Class="form-group row">
                    @Html.LabelFor(Function(m) m.EvenementZoneId, New With {.class = "col-sm-2 col-form-label required_field"})
                    <div class="col-sm-4 form-group">
                        @Html.DropDownListFor(Function(m) m.EvenementZoneId, New SelectList(Model.LesEvenementsZone, "Value", "Text"), Resource.ComboEvenement,
           New With {.class = "form-control single-select", .tabindex = "1", .Placeholder = Resource.EvenementCombo})
                        @Html.ValidationMessageFor(Function(m) m.EvenementZoneId, "", New With {.style = "color: #da0b0b"})
                    </div>
                    
                </div>

                @<fieldset style="border:ridge;" Class="col-md-12">
                     <legend style="font-size: 14px">@Resource.AutresImpactsHumainsEconomiques</legend>
                    <div Class="form-group row">
                        
                            <br />
                            <br />
                            <div Class="form-group row">
                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDePersonneEvacue, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDePersonneEvacue,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDePersonneEvacue, "", New With {.style = "color: #da0b0b"})
                                    </div>

                                </div>

                                <div Class="col-md-3">

                                    @Html.LabelFor(Function(m) m.NombreDePersonneAffecter, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDePersonneAffecter,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDePersonneAffecter, "", New With {.style = "color: #da0b0b"})
                                        
                                    </div>
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDePersonneDirrectementAffecter, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDePersonneDirrectementAffecter,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDePersonneDirrectementAffecter, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                                <div Class="col-md-3">
                                    @Html.LabelFor(Function(m) m.NombreDePersonneRelocaliser, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                    <div class="col-sm-8" style="max-width: 100%">
                                        @Html.EditorFor(Function(model) model.NombreDePersonneRelocaliser,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                        @Html.ValidationMessageFor(Function(m) m.NombreDePersonneRelocaliser, "", New With {.style = "color: #da0b0b"})
                                    </div>
                                    <br />
                                </div>

                            </div>                  

                    </div>

                    <div Class="form-group row">
                        <br />
                        <br />
                        <div Class="form-group row">
                            <div Class="col-md-3">
                                @Html.LabelFor(Function(m) m.TotalPerteEconomiqueLocalDevise, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.TotalPerteEconomiqueLocalDevise,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "2", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.TotalPerteEconomiqueLocalDevise, "", New With {.style = "color: #da0b0b"})
                                </div>

                            </div>

                            <div Class="col-md-3">

                                @Html.LabelFor(Function(m) m.TotalPerteEconomiqueDolar, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.TotalPerteEconomiqueDolar,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.TotalPerteEconomiqueDolar, "", New With {.style = "color: #da0b0b"})

                                </div>
                            </div>

                            <div Class="col-md-3">
                                @Html.LabelFor(Function(m) m.AutrePerte, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.AutrePerte,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.AutrePerte, "", New With {.style = "color: #da0b0b"})
                                </div>
                                <br />
                            </div>

                            <div Class="col-md-3">
                                @Html.LabelFor(Function(m) m.AmpleurDuDanger, New With {.class = "col-sm-4 col-form-label", .style = "font-size: 7px;  height: 25px; width:100%; max-width: 100%"})
                                <div class="col-sm-8" style="max-width: 100%">
                                    @Html.EditorFor(Function(model) model.AmpleurDuDanger,
New With {.htmlAttributes = New With {.class = "form-control", .tabindex = "3", .Placeholder = Resource.Valeur, .style = "font-size: 8px;  height: 25px; width:100%"}})
                                    @Html.ValidationMessageFor(Function(m) m.AmpleurDuDanger, "", New With {.style = "color: #da0b0b"})
                                </div>
                                <br />
                            </div>

                        </div>

                    </div>
                </fieldset>
                @<br />
                @<br />

                @<br />
                @<br />

                @<div Class="form-group row">

                    <Label Class="col-sm-1 col-form-label"></Label>
                    <div Class="col-sm-10">
                        <br />
                        <br />
                        <Button type="submit" Class="btn btn-link btn-square bg-warning text-dark shadow px-5"><i Class="icon-lock"></i> @Resource.Btn_Edit</Button>
                        &nbsp;&nbsp;&nbsp;
                        @Html.ActionLink(Resource.BtnCancel, "Index", "EvenementZones", Nothing, New With {.class = "btn btn-link btn-square bg-white text-dark shadow px-5"})
                    </div>
                </div>

            End Using

        </div>
    </div>
</div>

   
