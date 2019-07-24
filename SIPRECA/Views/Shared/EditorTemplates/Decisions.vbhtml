@ModelType String
@Imports SYGERME.My.Resources

@Code
    Dim data As New List(Of SelectListItem)
    
    data.Add(New SelectListItem() With {.Value = "Accepter", .Text = Resource.DecisionsAccepter})
    data.Add(New SelectListItem() With {.Value = "A réparer", .Text = Resource.DecisionsAReparer})
    data.Add(New SelectListItem() With {.Value = "A détruire", .Text = Resource.DecisionsADetruire})
End Code

@*@Html.DropDownList("", New SelectList(data, "Value", "Text", Model))*@
@Html.DropDownList("", New SelectList(data, "Value", "Text", Model), New With {.class = "form-control"})
