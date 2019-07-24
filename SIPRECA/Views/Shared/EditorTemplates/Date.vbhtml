@ModelType DateTime?
@*Using Date Template*@
@Code

    'Dim id = TagBuilder.CreateSanitizedId(String.Format("{0}_{1}_{2}", ViewData.TemplateInfo.HtmlFieldPrefix, "dt", 1))

    @If Model.HasValue Then
        @Html.TextBox("", String.Format("{0:d}", Model.Value.ToShortDateString()), New With {.type = "text", .class = "form-control"})
    Else
        @Html.TextBox("", "", New With {.type = "text", .class = "form-control"})
    End If

End code
