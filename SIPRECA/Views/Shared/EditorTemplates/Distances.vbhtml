@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)
    
    data.Add(New SelectListItem() With {.Value = "Km", .Text = "Km"})
    data.Add(New SelectListItem() With {.Value = "m", .Text = "m"})
End Code

@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
