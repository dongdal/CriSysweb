@ModelType DateTime?
@Code
    If Model.HasValue Then
        @String.Format("{0:d}", Model.Value.Date)
    End If
End code
