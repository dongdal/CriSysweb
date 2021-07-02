Public Class ModuleRoleComparer
    Implements IEqualityComparer(Of ModuleRole)

    Public Function Equals(x As ModuleRole, y As ModuleRole) As Boolean Implements IEqualityComparer(Of ModuleRole).Equals
        If x Is y Then Return True

        If x Is Nothing OrElse y Is Nothing Then Return False

        Return (x.ModulesId = y.ModulesId)
        'Return (x.Modules.Id = y.Modules.Id) AndAlso (x.AspNetRolesId = y.AspNetRolesId) AndAlso (x.AspNetUserId = y.AspNetUserId) AndAlso
        '    (x.ModulesId = y.ModulesId) AndAlso (x.DateCreation = y.DateCreation) AndAlso (x.StatutExistant = y.StatutExistant)
    End Function

    Public Function GetHashCode(obj As ModuleRole) As Integer Implements IEqualityComparer(Of ModuleRole).GetHashCode
        If obj Is Nothing Then Return 0
        'Dim hashModuleRoleId As Integer = If(obj.Id = Nothing, 0, obj.Id.GetHashCode())
        'Dim hashModuleRoleModuleId As Integer = obj.ModulesId.GetHashCode()
        Return obj.ModulesId.GetHashCode()
    End Function
End Class
