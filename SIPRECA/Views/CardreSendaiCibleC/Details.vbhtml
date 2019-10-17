@ModelType SIPRECA.CardreSendaiCibleA
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>CardreSendaiCibleA</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AspNetUser.Nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AspNetUser.Nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.EvenementZone.AspNetUserId)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.EvenementZone.AspNetUserId)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreTotalDeces)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreTotalDeces)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesFemme)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesFemme)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesHomme)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesHomme)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesEnfant)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesEnfant)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesAdult)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesAdult)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesVieux)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesVieux)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesHandicape)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesHandicape)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDecesPauvre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDecesPauvre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreTotalDisparue)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreTotalDisparue)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueFemme)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueFemme)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueHomme)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueHomme)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueEnfant)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueEnfant)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueAdult)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueAdult)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueVieux)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueVieux)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueHandicape)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparueHandicape)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.NombreDisparuePauvre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.NombreDisparuePauvre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.DateCreation)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.DateCreation)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.StatutExistant)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.StatutExistant)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", New With { .id = Model.Id }) |
    @Html.ActionLink("Back to List", "Index")
</p>
