Public Class BordereauTransfertDemande
    Public Property Id As Long
    Public Property DemandeId As Long
    Public Overridable Property Demande As Demande

    Public Property BordereauTransfertId As Long
    Public Overridable Property BordereauTransfert As BordereauTransfert

    Public Property DateCreation As DateTime = Now
    Public Property StatutExistant As Short = 1
End Class
