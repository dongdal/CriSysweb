@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
    Select Case Model
        Case "cm (Centimètre)"
            data = "cm (Centimètre)"
        Case "mm (Millimètre)"
            data = "mm (Millimètre)"
        Case Else
            data = "cm (Centimètre)"
    End Select

        @data

End Code