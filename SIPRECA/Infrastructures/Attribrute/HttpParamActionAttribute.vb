Imports System.Reflection

Public Class HttpParamActionAttribute
    Inherits ActionNameSelectorAttribute
    Public Overrides Function IsValidName(controllerContext As ControllerContext, actionName As String, methodInfo As MethodInfo) As Boolean
        If actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase) Then
            Return True
        End If

        Dim request = controllerContext.RequestContext.HttpContext.Request
        Return request(methodInfo.Name) IsNot Nothing
    End Function
End Class