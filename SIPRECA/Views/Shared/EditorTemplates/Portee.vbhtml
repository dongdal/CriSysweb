@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)

    data.Add(New SelectListItem() With {.Value = "t (Tonnes)", .Text = "t (Tonnes)"})
    data.Add(New SelectListItem() With {.Value = "Kg (Kilogramme)", .Text = "Kg (Kilogramme)"})
    data.Add(New SelectListItem() With {.Value = "g (Gramme)", .Text = "g (Gramme)"})
End Code

@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
