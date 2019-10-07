@ModelType EvenementZoneViewModel
@Imports SIPRECA.My.Resources
@Code
    ViewBag.Title = Resource.EditEvenementZone
    Layout = "~/Views/Shared/_LayoutDesinventar.vbhtml"
End Code

<div class="page-header">
    <h1 class="page-title">@Resource.ManageEvenementZone</h1>
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "Home")>@Resource.Menu_Home</a></li>
        <li class="breadcrumb-item"><a href=@Url.Action("Index", "EvenementZones")>@Resource.ManageEvenementZone</a></li>
        <li class="breadcrumb-item active">@Resource.EditEvenementZone</li>
    </ol>
</div>

<div class="container-fluid">
    <h6 class="text-uppercase">@Resource.EditEvenementZone</h6>
    <hr>
    @Using Html.BeginForm("Edit", "EvenementZones", FormMethod.Post, New With {.autocomplete = "off"})
        @Html.AntiForgeryToken()
        @Html.HiddenFor(Function(m) m.Id)
        @Html.HiddenFor(Function(m) m.StatutExistant)
        @Html.HiddenFor(Function(m) m.DateCreation)
        @Html.HiddenFor(Function(m) m.AspNetUserId)
        @<div class="row">

    <div Class="form-group row">

        @Html.LabelFor(Function(m) m.EvenementId, New With {.class = "col-sm-2 col-form-label required_field"})
        <div class="col-sm-4 form-group">
            @Html.DropDownListFor(Function(m) m.EvenementId, New SelectList(Model.LesEvenements, "Value", "Text"), Resource.ComboEvenement,
                           New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboEvenement})
            @Html.ValidationMessageFor(Function(m) m.EvenementId, "", New With {.style = "color: #da0b0b"})
        </div>

        @Html.LabelFor(Function(m) m.ZoneARisqueId, New With {.class = "col-sm-2 col-form-label required_field"})
        <div class="col-sm-4 form-group">
            @Html.DropDownListFor(Function(m) m.ZoneARisqueId, New SelectList(Model.LesZoneARisques, "Value", "Text"), Resource.ComboZoneARisque,
                           New With {.class = "form-control single-select", .tabindex = "2", .Placeholder = Resource.ComboZoneARisque})
            @Html.ValidationMessageFor(Function(m) m.ZoneARisqueId, "", New With {.style = "color: #da0b0b"})
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

    End Using

</div>
