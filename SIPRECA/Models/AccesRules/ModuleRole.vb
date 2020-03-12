Imports Microsoft.AspNet.Identity.EntityFramework

Public Class ModuleRole
    Public Property Id As Long
    Public Property ModulesId As Long
    Public Overridable Property Modules As Modules

    Public Property StatutExistant As Short = 1
    Public Property DateCreation As DateTime = Now()

    Public Property AspNetRolesId As String
    Public Overridable Property AspNetRoles As IdentityUserRole

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser
End Class