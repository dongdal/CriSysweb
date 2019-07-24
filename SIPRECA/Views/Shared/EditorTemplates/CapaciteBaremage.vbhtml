@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)

    data.Add(New SelectListItem() With {.Value = "l (Litre)", .Text = "l (Litre)"})
    data.Add(New SelectListItem() With {.Value = "m3 (Metre cube)", .Text = "m3 (Metre cube)"})
End Code

@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
