Imports System.Security.Principal
Imports System.Runtime.CompilerServices

Module MyExtensionModule
    <Extension()>
    Public Function IsInRole(principal As IPrincipal, ParamArray roles As String()) As Boolean
        For Each role In roles
            If principal.IsInRole(role) Then
                Return True
            End If
        Next

        Return False
    End Function

    <Extension()>
    Public Function IsInRole(principal As IPrincipal, str_roles As String) As Boolean
        Dim roles = str_roles.Split(",")
        For Each role In roles
            If principal.IsInRole(role.Trim) Then
                Return True
            End If
        Next

        Return False
    End Function

    ''' <summary>
    ''' Méthode d'extension permettant de vérifier si un entier passé en paramètre est l'identifiant d'une ressource accessible par un utilisateur.
    ''' </summary>
    ''' <param name="listRessource"></param>
    ''' <param name="RessourceId"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Contains(listRessource As List(Of Ressource), RessourceId As Long) As Boolean
        For Each ressource In listRessource
            If ressource.Id = RessourceId Then
                Return True
            End If
        Next
        Return False
    End Function

End Module
