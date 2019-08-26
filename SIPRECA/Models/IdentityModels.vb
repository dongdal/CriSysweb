Imports Microsoft.AspNet.Identity.EntityFramework
Imports Microsoft.AspNet.Identity


' You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
Public Class ApplicationUser
    Inherits IdentityUser

    Public Sub New()
        Abris = New HashSet(Of Abris)()
        AnneeBudgetaire = New HashSet(Of AnneeBudgetaire)()
        Article = New HashSet(Of Article)()
        BudgetCollectivite = New HashSet(Of BudgetCollectivite)()
        CategorieDArticle = New HashSet(Of CategorieDArticle)()
        Causes = New HashSet(Of Causes)()
        Champs = New HashSet(Of Champs)()
        'ChampsSection = New HashSet(Of ChampsSection)()
        Collectivite = New HashSet(Of Collectivite)()
        Indemnisation = New HashSet(Of Indemnisation)()
        Competance = New HashSet(Of Competance)()
        Demande = New HashSet(Of Demande)()
        DemandeArticle = New HashSet(Of DemandeArticle)()
        DemandeDArticle = New HashSet(Of DemandeDArticle)()
        Devise = New HashSet(Of Devise)()
        Enquete = New HashSet(Of Enquete)()
        Formulaire = New HashSet(Of Formulaire)()
        Immobilisation = New HashSet(Of Immobilisation)()
        Infrastructure = New HashSet(Of Infrastructure)()
        Maladie = New HashSet(Of Maladie)()
        MaladieSinistre = New HashSet(Of MaladieSinistre)()
        Moyen = New HashSet(Of Moyen)()
        NiveauDeRepresentation = New HashSet(Of NiveauDeRepresentation)()
        Oganisation = New HashSet(Of Organisation)()
        Personnel = New HashSet(Of Personnel)()
        PersonnelProjet = New HashSet(Of PersonnelProjet)()
        PieceJointe = New HashSet(Of PieceJointe)()
        Priorite = New HashSet(Of Priorite)()
        Secteur = New HashSet(Of Secteur)()
        Section = New HashSet(Of Section)()
        Sinistre = New HashSet(Of Sinistre)()
        Sinistrer = New HashSet(Of Sinistrer)()
        Site = New HashSet(Of Site)()
        Suivi = New HashSet(Of Suivi)()
        Taches = New HashSet(Of Tache)()
        TypeAbris = New HashSet(Of TypeAbris)()
        TypeChamps = New HashSet(Of TypeChamps)()
        TypeMoyen = New HashSet(Of TypeMoyen)()
        TypeOffice = New HashSet(Of TypeOffice)()
        TypeOrganisation = New HashSet(Of TypeOrganisation)()
        TypePersonnel = New HashSet(Of TypePersonnel)()
        TypeSinistre = New HashSet(Of TypeSinistre)()
        TypeSuivi = New HashSet(Of TypeSuivi)()
        ValeurChamps = New HashSet(Of ValeurChamps)()
        Zone = New HashSet(Of Zone)()
    End Sub

    Public Property Nom As String
    Public Property Prenom As String
    Public Property Sexe As String
    Public Property DateNaissance As Date?
    Public Property LieuNaissance As String
    Public Property CNI As String 'Carte Nationale d'Identité
    Public Property DateDelivranceCNI As Date
    Public Property DateExpirationCNI As Date
    Public Property AdresseUser As String
    Public Property Telephone As String
    Public Property Telephone2 As String
    'Public Property Email As String
    Public Property DateCreation As Date = Now
    Public Property Etat As Short = 1

    Public Property CommuneId As Long?
    Public Overridable Property Commune As Commune

    Public Property DepartementId As Long?
    Public Overridable Property Departement As Departement

    Public Property RegionId As Long?
    Public Overridable Property Region As Region

    Public Property Niveau As String

    Public Overridable Property Abris As ICollection(Of Abris)
    Public Overridable Property AnneeBudgetaire As ICollection(Of AnneeBudgetaire)
    Public Overridable Property Article As ICollection(Of Article)
    Public Overridable Property BudgetCollectivite As ICollection(Of BudgetCollectivite)
    Public Overridable Property CategorieDArticle As ICollection(Of CategorieDArticle)
    Public Overridable Property Causes As ICollection(Of Causes)
    Public Overridable Property Champs As ICollection(Of Champs)
    'Public Overridable Property ChampsSection As ICollection(Of ChampsSection)
    Public Overridable Property Collectivite As ICollection(Of Collectivite)
    Public Overridable Property Competance As ICollection(Of Competance)
    Public Overridable Property Demande As ICollection(Of Demande)
    Public Overridable Property DemandeArticle As ICollection(Of DemandeArticle)
    Public Overridable Property DemandeDArticle As ICollection(Of DemandeDArticle)
    Public Overridable Property Devise As ICollection(Of Devise)
    Public Overridable Property Enquete As ICollection(Of Enquete)
    Public Overridable Property Formulaire As ICollection(Of Formulaire)
    Public Overridable Property Immobilisation As ICollection(Of Immobilisation)
    Public Overridable Property Infrastructure As ICollection(Of Infrastructure)
    Public Overridable Property Indemnisation As ICollection(Of Indemnisation)
    Public Overridable Property Maladie As ICollection(Of Maladie)
    Public Overridable Property MaladieSinistre As ICollection(Of MaladieSinistre)
    Public Overridable Property Moyen As ICollection(Of Moyen)
    Public Overridable Property NiveauDeRepresentation As ICollection(Of NiveauDeRepresentation)
    Public Overridable Property Oganisation As ICollection(Of Organisation)
    Public Overridable Property Personnel As ICollection(Of Personnel)
    Public Overridable Property PersonnelProjet As ICollection(Of PersonnelProjet)
    Public Overridable Property PieceJointe As ICollection(Of PieceJointe)
    Public Overridable Property Priorite As ICollection(Of Priorite)
    Public Overridable Property Secteur As ICollection(Of Secteur)
    Public Overridable Property Section As ICollection(Of Section)
    Public Overridable Property Sinistre As ICollection(Of Sinistre)
    Public Overridable Property Sinistrer As ICollection(Of Sinistrer)
    Public Overridable Property Site As ICollection(Of Site)
    Public Overridable Property Suivi As ICollection(Of Suivi)
    Public Overridable Property Taches As ICollection(Of Tache)
    Public Overridable Property TypeAbris As ICollection(Of TypeAbris)
    Public Overridable Property TypeChamps As ICollection(Of TypeChamps)
    Public Overridable Property TypeMoyen As ICollection(Of TypeMoyen)
    Public Overridable Property TypeOffice As ICollection(Of TypeOffice)
    Public Overridable Property TypeOrganisation As ICollection(Of TypeOrganisation)
    Public Overridable Property TypePersonnel As ICollection(Of TypePersonnel)
    Public Overridable Property TypeSinistre As ICollection(Of TypeSinistre)
    Public Overridable Property TypeSuivi As ICollection(Of TypeSuivi)
    Public Overridable Property ValeurChamps As ICollection(Of ValeurChamps)
    Public Overridable Property Zone As ICollection(Of Zone)


End Class

Public Class IdentityManager
    Public Function RoleExists(name As String) As Boolean
        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
        Return rm.RoleExists(name)
    End Function


    Public Function CreateRole(name As String) As Boolean
        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
        Dim idResult = rm.Create(New IdentityRole(name))
        Return idResult.Succeeded
    End Function


    Public Function CreateUser(user As ApplicationUser, password As String) As Boolean
        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
        Dim idResult = um.Create(user, password)
        Return idResult.Succeeded
    End Function

    Public Function AddUserToRole(userId As String, roleName As String) As Boolean
        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
        Dim idResult = um.AddToRole(userId, roleName)
        Return idResult.Succeeded
    End Function


    Public Sub ClearUserRoles(userId As String)
        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
        Dim user = um.FindById(userId)
        Dim Db As New ApplicationDbContext
        Dim currentRoles = New List(Of IdentityUserRole)()
        currentRoles.AddRange(user.Roles)
        For Each role As IdentityUserRole In currentRoles
            Dim LeRole = (From rol In Db.Roles Where rol.Id = role.RoleId).FirstOrDefault
            Dim result = um.RemoveFromRole(role.UserId, LeRole.Name)
            Dim reussi = result.Succeeded
            'um.RemoveFromRole(userId, role.RoleId)
        Next
    End Sub


    'Public Function AddUserToRole(userId As String, roleName As String) As Boolean
    '    Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
    '    Dim idResult = um.AddToRole(userId, roleName)
    '    Return idResult.Succeeded
    'End Function


    'Public Sub ClearUserRoles(userId As String)
    '    Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
    '    Dim user = um.FindById(userId)
    '    Dim currentRoles = New List(Of IdentityUserRole)()
    '    currentRoles.AddRange(user.Roles)
    '    For Each role As IdentityUserRole In currentRoles
    '        um.RemoveFromRole(userId, role.RoleId)
    '    Next
    'End Sub
End Class

'Public Class IdentityManager
'    Public Function RoleExists(name As String) As Boolean
'        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
'        Return rm.RoleExists(name)
'    End Function


'    Public Function CreateRole(name As String) As Boolean
'        Dim rm = New RoleManager(Of IdentityRole)(New RoleStore(Of IdentityRole)(New ApplicationDbContext()))
'        Dim idResult = rm.Create(New IdentityRole(name))
'        Return idResult.Succeeded
'    End Function


'    Public Function CreateUser(user As ApplicationUser, password As String) As Boolean
'        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
'        Dim idResult = um.Create(user, password)
'        Return idResult.Succeeded
'    End Function


'    Public Function AddUserToRole(userId As String, roleName As String) As Boolean
'        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
'        Dim idResult = um.AddToRole(userId, roleName)
'        Return idResult.Succeeded
'    End Function


'    Public Sub ClearUserRoles(userId As String)
'        Dim um = New UserManager(Of ApplicationUser)(New UserStore(Of ApplicationUser)(New ApplicationDbContext()))
'        Dim user = um.FindById(userId)
'        Dim currentRoles = New List(Of IdentityUserRole)()
'        currentRoles.AddRange(user.Roles)
'        For Each role As IdentityUserRole In currentRoles
'            um.RemoveFromRole(userId, role.Role.Name)
'        Next
'    End Sub
'End Class