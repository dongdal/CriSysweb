@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case "Mois"
            data = "Mois"
        Case "Jours"
            data = "Jours"
        Case "Années"
            data = "Années"
    End Select

        @data

End Code