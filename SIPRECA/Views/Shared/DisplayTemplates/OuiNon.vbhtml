@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case "Oui"
            data = "Oui"
        Case "Non"
            data = "Non"
    End Select

        @data

End Code