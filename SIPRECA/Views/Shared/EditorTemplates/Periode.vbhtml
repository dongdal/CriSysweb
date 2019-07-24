@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)
    
    data.Add(New SelectListItem() With {.Value = "Mois", .Text = "Mois"})
    data.Add(New SelectListItem() With {.Value = "Jours", .Text = "Jours"})
    data.Add(New SelectListItem() With {.Value = "Années", .Text = "Années"})
End Code

@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
