@ModelType SIPRECA.Enquete
@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<div>
    <h4>Enquete</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(Function(model) model.AspNetUser.Nom)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.AspNetUser.Nom)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Sinistre.Libelle)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Sinistre.Libelle)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Titre)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Titre)
        </dd>

        <dt>
            @Html.DisplayNameFor(Function(model) model.Description)
        </dt>

        <dd>
            @Html.DisplayFor(Function(model) model.Description)
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
