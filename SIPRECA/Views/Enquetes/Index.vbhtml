@ModelType IEnumerable(Of SIPRECA.Enquete)
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
            @Html.DisplayNameFor(Function(model) model.Sinistre.Libelle)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Titre)
        </th>
        <th>
            @Html.DisplayNameFor(Function(model) model.Description)
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
            @Html.DisplayFor(Function(modelItem) item.Sinistre.Libelle)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Titre)
        </td>
        <td>
            @Html.DisplayFor(Function(modelItem) item.Description)
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
