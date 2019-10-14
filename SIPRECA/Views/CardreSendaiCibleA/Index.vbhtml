@ModelType IEnumerable(Of SIPRECA.CardreSendaiCibleA)
@Code
ViewData("Title") = "Index"
End Code

<h2>Index</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>
<table class="table">
    <tr>
        <th>
            @Html.DisplayNameFor(Function(model) model.AspNetUser.Nom)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.EvenementZone.AspNetUserId)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreTotalDeces)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesFemme)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesHomme)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesEnfant)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesAdult)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesVieux)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesHandicape)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDecesPauvre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreTotalDisparue)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueFemme)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueHomme)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueEnfant)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueAdult)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueVieux)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparueHandicape)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.NombreDisparuePauvre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.DateCreation)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.StatutExistant)
        </th>
        <th></th>
    </tr>

@For Each item In Model
    @<tr>
        <td>
            @Html.DisplayFor(Function(modelItem) item.AspNetUser.Nom)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.EvenementZone.AspNetUserId)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreTotalDeces)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesFemme)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesHomme)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesEnfant)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesAdult)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesVieux)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesHandicape)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDecesPauvre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreTotalDisparue)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueFemme)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueHomme)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueEnfant)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueAdult)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueVieux)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparueHandicape)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.NombreDisparuePauvre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.DateCreation)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.StatutExistant)
        </td>
        <td>
            @Html.ActionLink("Edit", "Edit", New With {.id = item.Id }) |
            @Html.ActionLink("Details", "Details", New With {.id = item.Id }) |
            @Html.ActionLink("Delete", "Delete", New With {.id = item.Id })
        </td>
    </tr>
Next

</table>
