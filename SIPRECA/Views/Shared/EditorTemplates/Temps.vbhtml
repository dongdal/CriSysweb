@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)
    
    data.Add(New SelectListItem() With {.Value = "H (Heure)", .Text = "H (Heure)"})
    data.Add(New SelectListItem() With {.Value = "M (Minutes)", .Text = "M (Minutes)"})
    data.Add(New SelectListItem() With {.Value = "S (Secondes)", .Text = "S (Secondes)"})
End Code

@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control", .disabled = "disabled"})*@
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
