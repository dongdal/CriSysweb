@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
    Select Case Model
        Case "l (Litre)"
            data = "l (Litre)"
        Case Else
            data = "l (Litre)"
    End Select

        @data

End Code