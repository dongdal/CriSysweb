Imports System.ComponentModel.DataAnnotations
Imports Microsoft.AspNet.Identity.EntityFramework
Imports SIPRECA.My.Resources

Public Class ExternalLoginConfirmationViewModel
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="GestUserUserName", ResourceType:=GetType(Resource))>
    Public Property UserName As String
End Class

Public Class ManageUserViewModel
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <DataType(DataType.Password)>
    <Display(Name:="GestUserActualPwd", ResourceType:=GetType(Resource))>
    Public Property OldPassword As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdLength", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwdNew", ResourceType:=GetType(Resource))>
    Public Property NewPassword As String

    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwdConfNew", ResourceType:=GetType(Resource))>
    <Compare("NewPassword", ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdConfNewMatch")>
    Public Property ConfirmPassword As String
End Class

<MetadataType(GetType(LoginViewModel))>
Public Class LoginViewModel
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="GestUserUserName", ResourceType:=GetType(Resource))>
    Public Property UserName As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwd", ResourceType:=GetType(Resource))>
    Public Property Password As String

    '<Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    '<Display(Name:="AnneeBudgetaire", ResourceType:=GetType(Resource))>
    'Public Property AnneeBudgetaireId As Long
    'Public Overridable Property LesAnneeBudgetaires As ICollection(Of SelectListItem)
    'Public Overridable Property AnneeBudgetaire As AnneeBudgetaire

    <Display(Name:="GestUserPwdMemo", ResourceType:=GetType(Resource))>
    Public Property RememberMe As Boolean
End Class

<MetadataType(GetType(RegisterViewModel))>
Public Class RegisterViewModel

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="GestUserUserName", ResourceType:=GetType(Resource))>
    Public Property UserName As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdLength", MinimumLength:=8)>
    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwd", ResourceType:=GetType(Resource))>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwdConf", ResourceType:=GetType(Resource))>
    <Compare("Password", ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdConfMatch")>
    Public Property ConfirmPassword As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Noms", ResourceType:=GetType(Resource))>
    Public Property Nom As String

    <Display(Name:="Prenoms", ResourceType:=GetType(Resource))>
    Public Property Prenom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Sexe", ResourceType:=GetType(Resource))>
    Public Property Sexe As String

    <Display(Name:="DateNaissance", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateNaissance As Date = Now

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="LieuNaissance", ResourceType:=GetType(Resource))>
    Public Property LieuNaissance As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CNI", ResourceType:=GetType(Resource))>
    Public Property CNI As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateDelivranceCNI", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDelivranceCNI As Date = Now

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateExpirationCNI", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateExpirationCNI As Date = Now

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="AdresseUser", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property AdresseUser As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    Public Property Telephone As String

    <Display(Name:="Telephone2", ResourceType:=GetType(Resource))>
    Public Property Telephone2 As String

    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    Public Property Email As String

    <Display(Name:="Etat", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property Etat As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Region", ResourceType:=GetType(Resource))>
    Public Property RegionId As Long?
    Public Overridable Property Regions As ICollection(Of SelectListItem)
    Public Overridable Property Region As Region

    <Display(Name:="Departement", ResourceType:=GetType(Resource))>
    Public Property DepartementId As Long?
    Public Overridable Property Departements As ICollection(Of SelectListItem)
    Public Overridable Property Departement As Departement

    <Display(Name:="QuartierCommune", ResourceType:=GetType(Resource))>
    Public Property CommuneId As Long?
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)
    Public Overridable Property Commune As Commune

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Niveau", ResourceType:=GetType(Resource))>
    Public Property Niveau As String
    Public Overridable Property LesNiveaux As ICollection(Of SelectListItem)

    Public Function GetUser() As ApplicationUser
        Dim user As New ApplicationUser
        With user
            .UserName = UserName
            .Nom = Nom
            .Prenom = Prenom
            .Sexe = Sexe
            .DateNaissance = DateNaissance
            .LieuNaissance = LieuNaissance
            .CNI = CNI
            .DateDelivranceCNI = DateDelivranceCNI
            .DateExpirationCNI = DateExpirationCNI
            .AdresseUser = AdresseUser
            .Telephone = Telephone
            .PhoneNumber = Telephone
            .PhoneNumberConfirmed = True
            .EmailConfirmed = True
            .Telephone2 = Telephone2
            .Email = Email
            .Etat = Etat
            .DateCreation = Now
            .RegionId = RegionId
            .DepartementId = DepartementId
            .CommuneId = CommuneId
            .Niveau = Niveau
        End With
        Return user
    End Function
End Class

<MetadataType(GetType(EditUserViewModel))>
Public Class EditUserViewModel

    Public Property Id As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="GestUserUserName", ResourceType:=GetType(Resource))>
    Public Property UserName As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <StringLength(100, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdLength", MinimumLength:=6)>
    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwd", ResourceType:=GetType(Resource))>
    Public Property Password As String

    <DataType(DataType.Password)>
    <Display(Name:="GestUserPwdConf", ResourceType:=GetType(Resource))>
    <Compare("Password", ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="GestUserPwdConfMatch")>
    Public Property ConfirmPassword As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Noms", ResourceType:=GetType(Resource))>
    Public Property Nom As String

    <Display(Name:="Prenoms", ResourceType:=GetType(Resource))>
    Public Property Prenom As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Sexe", ResourceType:=GetType(Resource))>
    Public Property Sexe As String

    <Display(Name:="DateNaissance", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateNaissance As Date

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="LieuNaissance", ResourceType:=GetType(Resource))>
    Public Property LieuNaissance As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="CNI", ResourceType:=GetType(Resource))>
    Public Property CNI As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateDelivranceCNI", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateDelivranceCNI As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateExpirationCNI", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateExpirationCNI As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="AdresseUser", ResourceType:=GetType(Resource))>
    <StringLength(4000, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="StringLongLength")>
    Public Property AdresseUser As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <RegularExpression("^\d{9}$", ErrorMessageResourceName:="PhoneNumberType", ErrorMessageResourceType:=GetType(Resource))>
    <Display(Name:="Telephone", ResourceType:=GetType(Resource))>
    Public Property Telephone As String

    <Display(Name:="Telephone2", ResourceType:=GetType(Resource))>
    Public Property Telephone2 As String

    <Display(Name:="Email", ResourceType:=GetType(Resource))>
    Public Property Email As String

    <Display(Name:="Etat", ResourceType:=GetType(Resource))>
    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Public Property Etat As Short = 1

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="DateCreation", ResourceType:=GetType(Resource))>
    <DataType(DataType.Date, ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="DateDataType")>
    Public Property DateCreation As DateTime = Now

    <Display(Name:="Region", ResourceType:=GetType(Resource))>
    Public Property RegionId As Long?
    Public Overridable Property Regions As ICollection(Of SelectListItem)
    Public Overridable Property Region As Region

    <Display(Name:="Departement", ResourceType:=GetType(Resource))>
    Public Property DepartementId As Long?
    Public Overridable Property Departements As ICollection(Of SelectListItem)
    Public Overridable Property Departement As Departement

    <Display(Name:="QuartierCommune", ResourceType:=GetType(Resource))>
    Public Property CommuneId As Long?
    Public Overridable Property LesCommunes As ICollection(Of SelectListItem)
    Public Overridable Property Commune As Commune

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="Niveau", ResourceType:=GetType(Resource))>
    Public Property Niveau As String
    Public Overridable Property LesNiveaux As ICollection(Of SelectListItem)

    Public Sub New()

    End Sub

    Public Sub New(user As ApplicationUser)

        With user
            UserName = .UserName
            Nom = .Nom
            Prenom = .Prenom
            Sexe = .Sexe
            DateNaissance = .DateNaissance
            LieuNaissance = .LieuNaissance
            CNI = .CNI
            DateDelivranceCNI = .DateDelivranceCNI
            DateExpirationCNI = .DateExpirationCNI
            AdresseUser = .AdresseUser
            Telephone = .Telephone
            Telephone2 = .Telephone2
            Email = .Email
            Etat = .Etat
            DateCreation = .DateCreation
            RegionId = .RegionId
            DepartementId = .DepartementId
            CommuneId = .CommuneId
            Niveau = .Niveau
        End With
    End Sub

    Public Function GetEntity(user As ApplicationUser, db As ApplicationDbContext) As ApplicationUser
        If db Is Nothing Then
            Throw New ArgumentNullException("db")
        End If
        With user
            .UserName = UserName
            .Nom = Nom
            .Prenom = Prenom
            .Sexe = Sexe
            .DateNaissance = DateNaissance
            .LieuNaissance = LieuNaissance
            .CNI = CNI
            .DateDelivranceCNI = DateDelivranceCNI
            .DateExpirationCNI = DateExpirationCNI
            .AdresseUser = AdresseUser
            .Telephone = Telephone
            .Telephone2 = Telephone2
            .EmailConfirmed = True
            .PhoneNumber = Telephone
            .PhoneNumberConfirmed = True
            .Email = Email
            .Etat = Etat
            .DateCreation = Now
            .RegionId = RegionId
            .DepartementId = DepartementId
            .CommuneId = CommuneId
            .Niveau = Niveau
        End With
        Return user
    End Function

End Class

Public Class SelectUserRolesViewModel

    Private Property M_Roles As List(Of SelectRoleEditorViewModel)

    Public Property Roles() As List(Of SelectRoleEditorViewModel)
        Get
            Return M_Roles
        End Get
        Set(value As List(Of SelectRoleEditorViewModel))
            M_Roles = value
        End Set
    End Property

    Private _Db As New ApplicationDbContext

    Public Function GetDb() As ApplicationDbContext
        Return _Db
    End Function

    Public Sub SetDb(AutoPropertyValue As ApplicationDbContext)
        _Db = AutoPropertyValue
    End Sub

    Public Property Id As String
    Property UserName As String
    Public Property Password As String
    Public Property ConfirmPassword As String
    Public Property Nom As String
    Public Property Prenom As String

    Public Sub New()
        Roles = New List(Of SelectRoleEditorViewModel)()
    End Sub

    ' Enable initialization with an instance of ApplicationUser:
    Public Sub New(user As ApplicationUser)
        Me.New()
        Id = user.Id
        UserName = user.UserName
        Nom = user.Nom
        Prenom = user.Prenom

        Dim allRoles = (From e In GetDb().Roles Select e).OrderBy(Function(r) r.Name).ToList
        Dim tempo = allRoles.Count
        For Each role As IdentityRole In allRoles
            ' An EditorViewModel will be used by Editor Template:
            Dim rvm = New SelectRoleEditorViewModel(role)
            Roles.Add(rvm)
        Next

        ' Set the Selected property to true for those roles for 
        ' which the current user is a member:
        For Each userRole As IdentityUserRole In user.Roles
            Dim LeRoleCourant = (From rol In GetDb().Roles Where rol.Id = userRole.RoleId Select rol).FirstOrDefault()
            Dim checkUserRole = Me.Roles.Find(Function(r) r.RoleName = LeRoleCourant.Name)
            checkUserRole.Selected = True
        Next
        'For Each userRole As IdentityUserRole In user.Roles
        '    'Dim LeRoleCourant = (From rol In GetDb().Roles Where rol.Id = userRole.RoleId Select rol).FirstOrDefault()
        '    Dim checkUserRole = Me.Roles.Find(Function(r) r.RoleName = userRole.Role.Name)
        '    checkUserRole.Selected = True
        'Next

    End Sub

End Class

Public Class SelectRoleEditorViewModel
    Public Sub New()
    End Sub

    Public Sub New(role As IdentityRole)
        RoleName = role.Name
    End Sub

    Private Property M_Selected As Boolean
    Public Property Selected() As Boolean
        Get
            Return M_Selected
        End Get
        Set(value As Boolean)
            M_Selected = value
        End Set
    End Property

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    Private Property M_RoleName As String
    Public Property RoleName() As String
        Get
            Return M_RoleName
        End Get
        Set(value As String)
            M_RoleName = value
        End Set
    End Property

End Class

Public Class RolesViewModel

    Public Property Id As String

    <Required(ErrorMessageResourceType:=GetType(Resource), ErrorMessageResourceName:="RequiredField")>
    <Display(Name:="RoleName", ResourceType:=GetType(Resource))>
    Public Property Name As String

    Public Sub New()

    End Sub

    Public Sub New(entity As IdentityRole)
        With Me
            .Id = entity.Id
            .Name = entity.Name
        End With
    End Sub

    Public Function GetEntity() As IdentityRole
        Dim entity As New IdentityRole
        With entity
            .Id = Id
            .Name = Name
        End With
        Return entity
    End Function

End Class