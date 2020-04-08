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

    ''' <summary>
    ''' Méthode d'extension permettant de vérifier si une liste d'éléments de type ActionSousRessource contient une référence pour une sous ressource et une action données.
    ''' </summary>
    ''' <param name="ListActionSousRessource"></param>
    ''' <param name="SousRessourceId"></param>
    ''' <param name="ActionId"></param>
    ''' <returns></returns>
    <Extension()>
    Public Function Contains(ListActionSousRessource As List(Of ActionSousRessource), SousRessourceId As Long, ActionId As Long) As Boolean
        For Each actionSousRessource In ListActionSousRessource
            If actionSousRessource.SousRessourceId = SousRessourceId And actionSousRessource.ActionsId = ActionId Then
                Return True
            End If
        Next
        Return False
    End Function
End Module
