@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)

    data.Add(New SelectListItem() With {.Value = "cm (Centimètre)", .Text = "cm (Centimètre)"})
    data.Add(New SelectListItem() With {.Value = "mm (Millimètre)", .Text = "mm (Millimètre)"})
End Code

@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
