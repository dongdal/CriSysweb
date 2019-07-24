@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case Resource.DecisionsAccepter
            data = "Accepter"
        Case Resource.DecisionsAReparer
            data = "A réparer"
        Case Resource.DecisionsADetruire
            data = "A détruire"
    End Select

        @data

End Code