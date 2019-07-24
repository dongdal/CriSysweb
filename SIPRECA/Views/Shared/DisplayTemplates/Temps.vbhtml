@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case "H (Heure)"
            data = "H (Heure)"
        Case "M (Minutes)"
            data = "M (Minutes)"
        Case "S (Secondes)"
            data = "S (Secondes)"
    End Select

        @data

End Code