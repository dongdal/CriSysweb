@ModelType SIPRECA.Alert
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Alert</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AspNetUser.Nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AspNetUser.Nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Organisation.Nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Organisation.Nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sinistre.LieuDuSinistre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sinistre.LieuDuSinistre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Contenu)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Contenu)
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
