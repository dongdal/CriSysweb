@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)

    data.Add(New SelectListItem() With {.Value = "Gravimétrie", .Text = "Gravimétrie"})
    data.Add(New SelectListItem() With {.Value = "Volumétrie", .Text = "Volumétrie"})
End Code

@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
