@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)
    
    data.Add(New SelectListItem() With {.Value = "Oui", .Text = "Oui"})
    data.Add(New SelectListItem() With {.Value = "Non", .Text = "Non"})
End Code

@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
