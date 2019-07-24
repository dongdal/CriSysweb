@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
    Select Case Model
        Case "Gravimétrie"
            data = "Gravimétrie"
        Case "Volumétrie"
            data = "Volumétrie"
        Case Else
            data = "Gravimétrie"
    End Select

        @data

End Code