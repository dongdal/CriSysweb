@ModelType SIPRECA.Alert
@Code
    ViewData("Title") = "Delete"
End Code

<h2>Delete</h2>

<h3>Are you sure you want to delete this?</h3>
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
    @Using (Html.BeginForm())
        @Html.AntiForgeryToken()

        @<div class="form-actions no-color">
            <input type="submit" value="Delete" class="btn btn-default" /> |
            @Html.ActionLink("Back to List", "Index")
        </div>
    End Using
</div>
