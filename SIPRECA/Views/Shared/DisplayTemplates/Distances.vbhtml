@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case "Km"
            data = "Km"
        Case "m"
            data = "m"
        Case Else
            data = "Km"
    End Select

        @data

End Code