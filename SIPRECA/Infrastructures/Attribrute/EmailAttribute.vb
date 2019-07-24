Imports Microsoft.VisualBasic
Imports System
Imports System.Globalization
Imports System.ComponentModel.DataAnnotations
Imports System.Text.RegularExpressions

<AttributeUsage(AttributeTargets.[Property] Or AttributeTargets.Field, AllowMultiple:=False)> _
Public NotInheritable Class EmailAttribute
    Inherits ValidationAttribute

    ' Internal field to hold the mask value. 
    ReadOnly _regex As String
    Public ReadOnly Property RegEx() As String
        Get
            Return _regex
        End Get
    End Property

    Public Sub New(ByVal regex As String)
        _regex = regex
    End Sub

    Private Const _format As String = "abc@def.xyz"
    Public ReadOnly Property Format() As String
        Get
            Return _format
        End Get
    End Property

    Public Overrides Function IsValid(ByVal value As Object) As Boolean
        Dim testedField As String = DirectCast(value, String)
        Dim result As Boolean = True
        result = MatchesRegex(Me.RegEx, testedField)
        Return result
    End Function

    ' Checks if the entered phone number matches the mask. 
    Public Shared Function MatchesRegex(ByVal regex As String, ByVal testedField As String) As Boolean
        If (String.IsNullOrEmpty(testedField)) Then
            Return True
        End If
        Dim RegExObject As New Regex(regex)
        Dim TheyMatch As Match = RegExObject.Match(testedField)
        Return TheyMatch.Success
    End Function

    Public Overrides Function FormatErrorMessage(ByVal name As String) As String
        Return [String].Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Me.Format)
    End Function
End Class
