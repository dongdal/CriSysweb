

Partial Public Class Immobilisation

    Public Property Id As Long
    Public Property TypeImmobilisationId As Long?
    Public Property InfrastructureId As Long
    Public Property FournisseurId As Long
    Public Property ElementId As Long

    Public Property NumeroImobilisation As String
    Public Property NumeroDeSerie As String
    Public Property DateAchat As Date
    Public Property PrixAchat As Double
    Public Property DeviseId As Long

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1

    Public Property AspNetUserId As String
    Public Overridable Property AspNetUser As ApplicationUser

    Public Overridable Property TypeImmobilisation As TypeImmobilisation
    Public Overridable Property Fournisseur As Organisation
    Public Overridable Property Infrastructure As Infrastructure
    Public Overridable Property Element As Element
    Public Overridable Property Devise As Devise
End Class
