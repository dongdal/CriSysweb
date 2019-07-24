@ModelType String
@Imports SYGERME.My.Resources

@Code

    Dim data As String = Resource.ComboSelect
        Select Case Model
        Case "t (Tonnes)"
            data = "t (Tonnes)"
        Case "Kg (Kilogramme)"
            data = "Kg (Kilogramme)"
        Case "g (Gramme)"
            data = "g (Gramme)"
        Case Else
            data = "t (Tonnes)"
    End Select

        @data

End Code