Imports System.Data.SqlClient

Public Class Util

    'https://social.msdn.microsoft.com/Forums/vstudio/en-US/ef77dc83-2796-406f-a95d-4cbf82c2e431/vbnet-generate-a-random-string-of-numbers-and-letters?forum=vbgeneral
    Public Shared Function GetRandomString() As String
        Dim p As String = System.IO.Path.GetRandomFileName()
        p = p.Replace(".", "").ToUpper
        Return p
    End Function

    ''' <summary>
    ''' The connection string property that pulls from the web.config
    ''' </summary>
    Public Shared ReadOnly Property ConnectionString() As String
        Get
            Return ConfigurationManager.ConnectionStrings("DefaultConnection").ConnectionString
        End Get
    End Property

    Shared Sub GetError(cex As Exception, modelState As ModelStateDictionary)
        If TypeOf (cex) Is Entity.Validation.DbEntityValidationException Then
            Dim ex = CType(cex, Entity.Validation.DbEntityValidationException)
            Dim strError As String = ""
            For Each val_errors In ex.EntityValidationErrors
                For Each val_error In val_errors.ValidationErrors
                    modelState.AddModelError(val_error.PropertyName, val_error.ErrorMessage)
                    strError &= val_error.ErrorMessage & vbCrLf
                Next
            Next
            modelState.AddModelError("", strError)
        ElseIf TypeOf (cex) Is Exception Then
            Dim ex = cex
            Dim strError As String = ""
            Dim ie = ex
            While ie IsNot Nothing
                If Not ie.Message.StartsWith("Une erreur") Then
                    strError &= ie.Message & "|"
                End If

                ie = ie.InnerException
            End While
            Dim ar_errors = strError.Split("|".ToCharArray)
            For Each val_error In ar_errors
                modelState.AddModelError("", val_error)
            Next
        End If
    End Sub

    Shared Function GetError(cex As Exception) As String
        Dim strError As String = ""
        If TypeOf (cex) Is Entity.Validation.DbEntityValidationException Then
            Dim ex = CType(cex, Entity.Validation.DbEntityValidationException)
            For Each val_errors In ex.EntityValidationErrors
                For Each val_error In val_errors.ValidationErrors
                    strError &= val_error.ErrorMessage & vbCrLf
                Next
            Next

        ElseIf TypeOf (cex) Is Exception Then
            Dim ex = cex
            Dim ie = ex
            While ie IsNot Nothing
                If Not ie.Message.StartsWith("Une erreur") Then
                    strError &= ie.Message & "|"
                End If

                ie = ie.InnerException
            End While
        End If

        Return strError
    End Function

    Shared Function GetModelStateError(ms As ModelStateDictionary) As Object
        Dim query = From state In ms.Values
                    From erreur In state.Errors
                    Select erreur.ErrorMessage

        Dim strError As String = ""
        For Each val_error In query
            strError &= val_error & vbCrLf
        Next
        Return strError
    End Function

    'Public Shared Function GetNumeroSuivi() As String

    '    Dim LeNumeroSuivi As String = "" 'AppSession.ServiceUtilisateur.AbrService & "-"
    '    If Not (String.IsNullOrEmpty(AppSession.ServiceUtilisateur.AbrService)) Then
    '        LeNumeroSuivi = AppSession.ServiceUtilisateur.AbrService & "-"
    '    End If
    '    LeNumeroSuivi = LeNumeroSuivi & Now.DayOfYear().ToString & (Now.Hour * 3600 + Now.Minute * 60 + Now.Second).ToString & Now.ToString("yy") & "-"
    '    LeNumeroSuivi += AppSession.ServiceUtilisateur.AbrServiceEn
    '    Return LeNumeroSuivi.ToUpper
    'End Function

    '[Enum].GetName(GetType(Util.ElementsSuiviDemandes), Util.ElementsSuiviDemandes.Creation)

    Public Enum ElementsSuiviDemandes
        ''' <summary>
        ''' Valeur utilisée lors de la création de la demande d'indemnisation au niveau communal
        ''' </summary>
        CreationCommunal = 1

        ''' <summary>
        ''' Valeur utilisée lors de la validation au niveau communal
        ''' </summary>
        ValidationCommunal = 2

        ''' <summary>
        ''' Valeur utilisée lors du rejet d'un dossier de la commune 
        ''' </summary>
        RejetCommunal = -1

        ''' <summary>
        ''' Valeur utilisée lors du transfert d'un dossier de la commune vers le département
        ''' </summary>
        TransfertCommunal = 3

        ''' <summary>
        ''' Reception du dossier au niveau départemental
        ''' </summary>
        ReceptionDepartemental = 4

        ''' <summary>
        ''' Creation du dossier au niveau départemental
        ''' </summary>
        CreationDepartemental = 5

        ''' <summary>
        ''' Validation du dossier au départemental 
        ''' </summary>
        ValidationDepartemental = 6

        ''' <summary>
        ''' Valeur utilisée lors du rejet d'un dossier du departement 
        ''' </summary>
        RejetDepartemental = -2

        ''' <summary>
        ''' Valeur utilisée lors du transfert d'un dossier du departement vers le regional
        ''' </summary>
        TransfertDepartemental = 7

        ''' <summary>
        ''' Reception du dossier au niveau régional
        ''' </summary>
        ReceptionRegionale = 8

        ''' <summary>
        ''' Creation du dossier du niveau régional
        ''' </summary>
        CreationRegional = 9

        ''' <summary>
        ''' La demande d'indemnisation a été rejetée au niveau regional
        ''' </summary>
        RejetRegional = -3

        ''' <summary>
        ''' Validation du dossier au niveau regional
        ''' </summary>
        ValidationRegional = 10

        ''' <summary>
        ''' transfert du dossier au niveau regional vers niveau national
        ''' </summary>
        TransfertRegional = 11

        ''' <summary>
        ''' Reception du dossier au niveau national
        ''' </summary>
        ReceptionNational = 12

        ''' <summary>
        ''' Creation du dossier du niveau national
        ''' </summary>
        CreationNational = 13

        ''' <summary>
        ''' Validation du dossier au niveau national
        ''' </summary>
        ValidationNational = 14

        ''' <summary>
        ''' La demande d'indemnisation a été rejetée au niveau national
        ''' </summary>
        RejetNational = 15

        ''' <summary>
        ''' La demande d'indemnisation a été approuvée
        ''' </summary>
        DecisionIndemnisation = 16
    End Enum

    Public Enum UserLevel
        ''' <summary>
        ''' Utilisateur de niveau communal
        ''' </summary>
        Communal = 1

        ''' <summary>
        ''' Utilisateur de niveau départemental
        ''' </summary>
        Departemental = 2

        ''' <summary>
        ''' Utilisateur de niveau régional
        ''' </summary>
        Regional = 3

        ''' <summary>
        ''' Utilisateur de niveau national
        ''' </summary>
        National = 4

        ''' <summary>
        ''' Pour les autres types d'utilisateur
        ''' </summary>
        Autre = 5
    End Enum

    Public Enum StatutDemande
        ''' <summary>
        ''' La demande est toujours en cours de traitement
        ''' </summary>
        EnCours = 1

        ''' <summary>
        ''' La demande a été rejetée
        ''' </summary>
        Rejetee = 2

        ''' <summary>
        ''' La demande a été approuvée
        ''' </summary>
        Approuvee = 3
    End Enum

End Class