'Public Class SharedFunctions

Imports System.Globalization
Imports System.ComponentModel.DataAnnotations

<AttributeUsage(AttributeTargets.[Property] Or AttributeTargets.Field, AllowMultiple:=False)> _
Public NotInheritable Class CustomAttribute
    Inherits ValidationAttribute

    ' Internal field to hold the mask value. 
    ReadOnly _mask As String
    Public ReadOnly Property Mask() As String
        Get
            Return _mask
        End Get
    End Property

    Public Sub New(ByVal mask As String)
        _mask = mask
    End Sub

    Public Overrides Function IsValid(ByVal value As Object) As Boolean
        Dim phoneNumber As String = DirectCast(value, String)
        Dim result As Boolean = True
        If Me.Mask <> Nothing Then
            result = MatchesMask(Me.Mask, phoneNumber)
        End If
        Return result
    End Function

    ' Checks if the entered phone number matches the mask. 
    Public Shared Function MatchesMask(ByVal mask As String, ByVal phoneNumber As String) As Boolean
        If (String.IsNullOrEmpty(phoneNumber)) Then
            Return True
        End If
        If mask.Length <> phoneNumber.Trim().Length Then
            ' Length mismatch. 
            Return False
        End If
        Dim i As Integer = 0
        While i < mask.Length
            If mask(i) = "d"c AndAlso Char.IsDigit(phoneNumber(i)) = False Then
                ' Digit expected at this position.       
                Return False
            End If
            If mask(i) = "-"c AndAlso phoneNumber(i) <> "-"c Then
                ' Spacing character expected at this position. 
                Return False
            End If
            System.Math.Max(System.Threading.Interlocked.Increment(i), i - 1)
        End While
        Return True
    End Function

    Public Overrides Function FormatErrorMessage(ByVal name As String) As String
        Return [String].Format(CultureInfo.CurrentCulture, ErrorMessageString, name, Me.Mask)
    End Function


End Class

'<MetadataType(GetType(CustomerMetadata))>
'Partial Public Class Customer
'End Class

'Public Class CustomerMetadata
'    <CustomAttribute("999-999-9999", _
'    ErrorMessage:="{0} field value does not match the mask {1}.")> _
'    Public Phone As Object

'End Class